using System.Diagnostics;
using Anotar.Serilog;

namespace Raft.Office.Excel;

public abstract class ExcelReaderBase<TBook, TSheet, TRow, TCell> : IExcelReader<TBook, TSheet, TRow, TCell>
    where TBook : IBook<TSheet, TRow, TCell>
    where TSheet : ISheet<TRow, TCell>
    where TRow : IRow<TCell>
    where TCell : ICell
{
    protected abstract TCell? ReadCell(NPOI.SS.UserModel.ICell cell);
    protected abstract TRow? ReadRow(NPOI.SS.UserModel.IRow row, IList<TCell> cells);
    protected abstract TSheet? ReadSheet(NPOI.SS.UserModel.ISheet sheet, IList<TRow> rows);
    protected abstract TBook? ReadBook(NPOI.SS.UserModel.IWorkbook workbook, IList<TSheet> sheets);

    public TBook? Read(Stream stream)
    {
        var stopwatch = Stopwatch.StartNew();

        var workBook = NPOI.SS.UserModel.WorkbookFactory.Create(stream);

        IList<TSheet> sheets = new List<TSheet>();

        for (var sheetIndex = 0; sheetIndex < workBook.NumberOfSheets; sheetIndex++)
        {
            var workSheet = workBook.GetSheetAt(sheetIndex);

            IList<TRow> rows = new List<TRow>();

            foreach (NPOI.SS.UserModel.IRow workRow in workSheet)
            {
                IList<TCell> cells = new List<TCell>();

                foreach (var workCell in workRow.Cells)
                {
                    var cell = ReadCell(workCell);

                    if (cell != null)
                    {
                        cells.Add(cell);
                    }
                }

                if (cells.IsNullOrEmpty())
                {
                    continue;
                }

                var row = ReadRow(workRow, cells);

                if (row != null)
                {
                    rows.Add(row);
                }
            }

            if (rows.IsNullOrEmpty())
            {
                continue;
            }

            var sheet = ReadSheet(workSheet, rows);

            if (sheet != null)
            {
                sheets.Add(sheet);
            }
        }

        TBook? book = default;

        if (sheets.IsNotNullOrEmpty())
        {
            book = ReadBook(workBook, sheets);
        }

        stopwatch.Stop();

        LogTo.Information("Finished reading the excel file ({ElapsedMilliseconds}ms)", stopwatch.ElapsedMilliseconds);

        return book;
    }
}
