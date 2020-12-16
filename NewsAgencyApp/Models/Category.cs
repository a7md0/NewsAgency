using System;
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

        public override Boolean create()
        {

            return false;
        }

        public override Boolean update()
        {

            return false;
        }

        public override Boolean remove()
        {

            return false;
        }
    }
}
