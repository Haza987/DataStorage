using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static CustomerEntity Create(CustomerDto customerDto) => new()
    {
        FirstName = customerDto.FirstName,
        LastName = customerDto.LastName,
        Email = customerDto.Email,
        PhoneNumber = customerDto.PhoneNumber
    };

    public static Customer Create(CustomerEntity customerEntity) => new()
    {
        CustomerName = $"{customerEntity.FirstName} {customerEntity.LastName}",
        Email = customerEntity.Email,
        PhoneNumber = customerEntity.PhoneNumber,
        Address = customerEntity.Address
    };

    public static CustomerEntity Update(CustomerEntity customerEntity, CustomerUpdateDto customerUpdateDto)
    {
        customerEntity.FirstName = customerUpdateDto.FirstName ?? customerEntity.FirstName;
        customerEntity.LastName = customerUpdateDto.LastName ?? customerEntity.LastName;
        customerEntity.Email = customerUpdateDto.Email ?? customerEntity.Email;
        customerEntity.PhoneNumber = customerUpdateDto.PhoneNumber ?? customerEntity.PhoneNumber;
        customerEntity.Address = customerUpdateDto.Address ?? customerEntity.Address;

        return customerEntity;
    }
}
