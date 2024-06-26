﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleWebApiCore.Models;

namespace SampleWebApiCore.Contracts
{
   public interface ICustomerRepository
   {
       IEnumerable<Customer> GetAll();
       Task<Customer> Add(Customer customer);
       Task<Customer> Find(int id);
       Task<Customer> Update(Customer customer);
       Task<Customer> Remove(int id);
       Task<bool> IsExists(int id);
       Task<int> CountCustomer();

   }
}
