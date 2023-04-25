namespace CRMMarten;

using Marten;

using System.Collections.Generic;
using System.Linq;

public class CustomerRepository
{
    private readonly IDocumentStore _store;

    public CustomerRepository(IDocumentStore store)
    {
        _store = store;
    }

    public IEnumerable<Customer> GetAll()
    {
        using var session = _store.QuerySession();
        return session.Query<Customer>().ToList();
    }

    public Customer GetById(int id)
    {
        using var session = _store.QuerySession();
        return session.Load<Customer>(id);
    }

    public void Create(Customer customer)
    {
        using var session = _store.OpenSession();
        session.Insert(customer);
        session.SaveChanges();
    }

    public void Update(Customer customer)
    {
        using var session = _store.OpenSession();
        session.Update(customer);
        session.SaveChanges();
    }

    public void Delete(int id)
    {
        using var session = _store.OpenSession();
        session.Delete<Customer>(id);
        session.SaveChanges();
    }
}
