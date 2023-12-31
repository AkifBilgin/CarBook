﻿using CarBook.DataAccessLayer.Abstract;
using CarBook.DataAccessLayer.Concrete;
using CarBook.DataAccessLayer.Repositories;
using CarBook.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetAllCommentsWithCar()
        {
            using CarBookContext context = new CarBookContext();
            var values = context.Comments.Include(c=>c.Car).ThenInclude(b=>b.Brand).ToList();
            return values;
        }

        public List<Comment> GetCommentsByCarId(int id)
        {
            using (CarBookContext context = new CarBookContext())
            {
              var values = context.Comments.Where(x=>x.CarID == id).ToList();
                return values;
            }
        }
    }
}
