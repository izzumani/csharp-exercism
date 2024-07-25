using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Dispose()
    {
        database.Dispose();
    }

    public void Write(string data)
    {
        try
        {
            database.BeginTransaction();

            database.Write(data);

            database.EndTransaction();
        }
        catch (InvalidOperationException e)
        {
            database.Dispose();
            throw e;
        }
        

    }

    public bool WriteSafely(string data)
    {
        try
        {

            database.BeginTransaction();

            database.Write(data);

            database.EndTransaction();

            return true;
        }
        catch (InvalidOperationException e)
        {
            database.Dispose();
            return false;
        }
    }
}
