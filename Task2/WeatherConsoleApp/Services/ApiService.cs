using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsoleApp.Services
{
    public class ApiService
    {
        // 1.Method Fetch
        // makes the calls to https://api.openweathermap.org/ 
        // serializes response to WeatherModel
        // if model is not null
        // calls private method SaveInDb to save data

        //2.Method SaveInDB(WeatherModel model)
        // Convert WeatherModel to WeatherDTO dto
        // _dbService.Save(dto);

}
}
