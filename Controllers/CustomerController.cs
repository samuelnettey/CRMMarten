using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMMarten.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerRepository _repository;

    public CustomerController(CustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAllCustomers()
    {
        var customers = _repository.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _repository.GetById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer(Customer customer)
    {
        _repository.Create(customer);
        return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest();
        }

        _repository.Update(customer);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        _repository.Delete(id);
        return NoContent();
    }
}
