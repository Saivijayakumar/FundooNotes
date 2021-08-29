﻿using FundooNotes.Managers.Interface;
using FundooNotes.Models;
using FundooNotes.Repository.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Managers.Manger
{
    public class UserManager : IUserManger
    {
        private readonly IUserRepository repository;
        public  UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Login(LoginModel userData)
        {
            try
            {
                return this.repository.Login(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
