﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PublisherWebAPI.Entities;

namespace PublisherWebAPI.Services
{
    public class GenericEFRepository : IGenericEFRepository
    {
        private SqlDbContext _db;

        public GenericEFRepository(SqlDbContext db)
        {
            _db = db;
        }
    }
}