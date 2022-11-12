using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context; //nao é possivel mudar

    public LabController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Labs);
    }

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    public IActionResult Delete(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }
        
        _context.Labs.Remove(_context.Labs.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Add(Lab lab)
    {
        _context.Labs.Add(lab);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(Lab lab, int id)
    {
        Lab updateLab = _context.Labs.Find(lab.Id);
        
        updateLab.Number = lab.Number;
        updateLab.Name = lab.Name;
        updateLab.Block = lab.Block;

        _context.Labs.Update(updateLab);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


}