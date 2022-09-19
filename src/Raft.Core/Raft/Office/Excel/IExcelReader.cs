namespace Raft.Office.Excel;

public interface IExcelReader<out TBook, TSheet, TRow, TCell>
    where TBook : IBook<TSheet, TRow, TCell>
    where TSheet : ISheet<TRow, TCell>
    where TRow : IRow<TCell>
    where TCell : ICell
{
    TBook? Read(Stream stream);
}
