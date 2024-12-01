using System.Numerics;

namespace PenkiControlApp.Core.Types;

public class Result<T>(T? some, Exception? err)
{
    private T? _some = some;
    private Exception? _err = err;

    public bool IsSome()
    {
        return _some is not null and not 0;
    }

    public bool IsErr()
    {
        return _some is not null;
    }

    public T Unwrap()
    {
        return _some!;
    }

    public Exception Except()
    {
        return _err!;
    }
}