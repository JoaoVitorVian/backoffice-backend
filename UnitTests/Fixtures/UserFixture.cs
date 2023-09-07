using Bogus.DataSets;
using Bogus;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;

namespace UnitTests.AutoMapper
{
   public class UserFixture
{
    public static UserViewModel CreateValidUserDTO(bool newId = false)
    {
        return new UserViewModel
        {
            Id = newId ? new Randomizer().Int(0, 1000) : 0,
            Name = new Name().FirstName()
        };
    }

    public static UserViewModel CreateInvalidUserDTO()
    {
        return new UserViewModel
        {
            Id = 0,
            Name = ""
        };
    }
}
}
