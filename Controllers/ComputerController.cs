using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context; //nao é possivel mudar

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Computers);
    }

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    public IActionResult Delete(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }
        
        _context.Computers.Remove(_context.Computers.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Computer pc)
    {
        _context.Computers.Add(pc);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Computer pc, int id)
    {
        Computer updateComputer = _context.Computers.Find(pc.Id);
        
        updateComputer.Ram = pc.Ram;
        updateComputer.Processor = pc.Processor;

        _context.Computers.Update(updateComputer);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}