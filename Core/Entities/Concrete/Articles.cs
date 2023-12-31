﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Articles : BaseEntity, IEntity
    {
        public int ArticleId { get; set; }

        public string Title { get; set;}
        public string Slug { get; set;}
        public string Description { get; set;}
        public string Content { get; set;}
        public User Author { get; set;}

        public Category Category { get; set;}
    }
}
