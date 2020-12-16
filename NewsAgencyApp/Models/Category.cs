﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAgencyApp.Models
{
    class Category : Model
    {
        private int id;
        private string name;
        private int numberOfArticles;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int NumberOfArticles
        {
            get
            {
                return numberOfArticles;
            }

            set
            {
                numberOfArticles = value;
            }
        }

        public Category()
        {
        }

        public Category(int id, string name, int numberOfArticles)
        {
            this.id = id;
            this.name = name;
            this.numberOfArticles = numberOfArticles;
        }

        public Category(string name)
        {
            this.name = name;
            this.numberOfArticles = 0;
        }

        public override bool Create()
        {

            return false;
        }

        public override bool Update()
        {

            return false;
        }

        public override bool Remove()
        {

            return false;
        }
    }
}
