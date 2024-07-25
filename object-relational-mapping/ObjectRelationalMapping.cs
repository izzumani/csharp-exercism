using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException e)
        {

            database.Dispose();

            
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException e)
        {

            database.Dispose();
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
