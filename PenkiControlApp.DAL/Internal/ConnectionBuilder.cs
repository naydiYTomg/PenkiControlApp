using Dapper;
using Npgsql;
using PenkiControlApp.Core;

namespace PenkiControlApp.DAL.Internal;

public class Connection(string connectionString, string query, object? properties)
{
    private string _connectionString = connectionString;
    private object? _properties = properties;
    private string _query = query;

    public T ExecuteFirst<T>()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            if (_properties is null)
            {
                T result = connection.Query<T>(_query).First();
                return result;
            }
            else
            {
                T result = connection.Query<T>(_query, _properties).First();
                return result;
            }
        }
    }

    public IEnumerable<T> Execute<T>()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            if (_properties is null)
            {
                var result = connection.Query<T>(_query);
                return result;
            }
            else
            {
                var result = connection.Query<T>(_query, _properties);
                return result;
            }
        }
    }

    public void ExecuteNoReturn()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            if (_properties is null)
            {
                connection.Query(_connectionString);
            }
            else
            {
                connection.Query(_connectionString, _properties);
            }
        }
    }

    public ConnectionBuilder Unpack() => new ConnectionBuilder().WithQuery(_query).WithProperties(_properties);
}

public class ConnectionBuilder
{
    private string _connectionString;
    private object? _properties = null;
    private string _query;
    
    
    public ConnectionBuilder()
    {
        _connectionString = Constants.CONNECTION_INFO;
    }

    public ConnectionBuilder WithQuery(string query)
    {
        _query = query;
        return this;
    }

    public ConnectionBuilder WithProperties(object? properties)
    {
        _properties = properties;
        return this;
    }

    public Connection Pack()
    {
        return new Connection(_connectionString, _query, _properties);
    }
    
}