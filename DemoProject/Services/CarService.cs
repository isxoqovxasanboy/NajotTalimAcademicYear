using DemoProject.Data;
using DemoProject.Models;

namespace DemoProject.Services;

public class CarService : ICarService
{
    private readonly AppDataContext _context;

    public CarService(AppDataContext context)
    {
        _context = context;
    }

    public Task<List<Car>> GetAsync()
    {
        var result = Task.Run(() => _context.Cars.ToList());
        return result;
    } 

    public async Task<Car> CreatCarAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public  Task<bool> UpdateCarAsync(Car car)
    {
        var result = Task.Run(() =>
        {
            try
            {
                _context.Cars.Update(car);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        });

        return result;
    }

    public Task<bool> DeleteCarAsync(Car car)
    {
        var result = Task.Run(() =>
        {
            try
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        });
        return result;
    }
}