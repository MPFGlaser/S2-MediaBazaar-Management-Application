﻿using System.Collections.Generic;

namespace MediaBazaar_ManagementSystem
{
    public interface IEmployeeStorage
    {
        bool Create(Employee employee);

        bool Update(Employee employee);

        Employee Get(int id);

        List<Employee> GetAll(bool activeOnly);
    }
}