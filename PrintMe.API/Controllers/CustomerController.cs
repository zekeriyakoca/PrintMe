using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintMe.Application.Entities;
using PrintMe.Application.Interfaces.Repositories;

namespace PrintMe.API.Controllers;

public class CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository) : BaseController(logger)
{
    [HttpGet]
    public async Task<ActionResult<Customer>> GetCustomer()
    {
        if (string.IsNullOrWhiteSpace(CurrentUser.Id))
        {
            return BadRequest("User doesn't exist.");
        }

        var customer = await customerRepository.GetCustomer(CurrentUser.Id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCustomer([FromRoute] string id, [FromBody] Customer customer)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return BadRequest("Id is not valid.");
        }

        if (id != customer.Id)
        {
            return BadRequest("Id does not match.");
        }

        await customerRepository.UpdateCustomer(customer);

        return Ok();
    }

    [HttpPost]
    [Authorize(Policy = "User")]
    public async Task<ActionResult> CreateCustomer()
    {
        if (await customerRepository.Exist(CurrentUser.Id))
        {
            return Ok();
        }

        if (CurrentUser.Email == null)
        {
            Logger.LogError("User does not have an email address. User: {user}", JsonSerializer.Serialize(CurrentUser));
            return BadRequest("User could not be created!");
        }

        var customer = new Customer()
        {
            Id = CurrentUser.Id,
            FullName = CurrentUser.UserName,
            Email = CurrentUser.Email ?? string.Empty,
            ProfilePictureUrl = CurrentUser.ProfilePictureUrl
        };
        await customerRepository.CreateCustomer(customer);

        return Ok();
    }
}