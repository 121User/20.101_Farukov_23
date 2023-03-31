using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._101_Farukov_23
{
    internal class Helper
    {
		private static Entity.EntitiesLibrary DBEntities;
		public static Entity.EntitiesLibrary getContex()
		{
			if (DBEntities == null)
			{
				DBEntities = new Entity.EntitiesLibrary();
			}
			return DBEntities;
		}

		//Поиск специальности по названию
		public static int getIdSpeciality(string title)
		{
			int id = 0;
			id = DBEntities.Speciality.Where(spec => spec.Title.ToLower().Contains(title.ToLower())).First().IdSpeciality;

			return id;
		}
	}
}
