using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreYourPoint.Dto;

namespace ScoreYourPoint.Services.Sports
{
    public class SportService
    {
        public ProfileDto GetSportById(int id)
        {
			var Profile = await _dataContext.Profiles.FirstOrDefaultAsync(pro => pro.Id == id);

			if (Profile == null)
			{
				throw new Exception("Profile not found");
			}

			return new ProfileDto(Profile);
		}
    }
}
