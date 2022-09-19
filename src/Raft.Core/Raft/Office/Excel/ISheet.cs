namespace Raft.Office.Excel;

public interface ISheet<out TRow, TCell>
    where TRow : IRow<TCell>
    where TCell : ICell
{
    int Index { get; }

    string Name { get; }

    TRow[] Rows { get; }
}
