namespace Raft.Office.Excel;

public interface IBook<out TSheet, TRow, TCell>
    where TSheet : ISheet<TRow, TCell>
    where TRow : IRow<TCell>
    where TCell : ICell
{
    TSheet[] Sheets { get; }
}
