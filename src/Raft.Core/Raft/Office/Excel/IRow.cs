namespace Raft.Office.Excel;

public interface IRow<out TCell>
    where TCell : ICell
{
    int Index { get; }

    TCell[] Cells { get; }
}
