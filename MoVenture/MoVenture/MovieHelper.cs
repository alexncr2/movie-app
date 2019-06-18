using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoVenture.Models;

namespace MoVenture
{
    public class MovieHelper
    {
        private static List<CategoryModel> mMinCategories;
        private static List<MinifiedMovie> mMinMovies;

        public static List<CategoryModel> MinCategories
        {
            get
            {
                return mMinCategories;
            }
            set
            {
                mMinCategories = value;
                mMinMovies = new List<MinifiedMovie>();
                foreach (CategoryModel c in mMinCategories)
                {
                    mMinMovies.AddRange(c.MovieList);
                }
            }
        }

        public static List<MinifiedMovie> MinMovies
        {
            get
            {
                return mMinMovies;
            }
            set
            {
                MinMovies = value;
            }
        }

    }
}