using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Data;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace assignment1.Controllers;

[Authorize(Roles = "Admin, Owner")]
public class ManifestsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ManifestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> GeneratePDFReport()
    {
        var ms = new MemoryStream();

        // Create a PdfWriter instance directing it to write to the MemoryStream.
        var writer = new PdfWriter(ms);
        var pdfDoc = new PdfDocument(writer);
        var document = new Document(pdfDoc, PageSize.A4);
        writer.SetCloseStream(false);

        // Header
        Paragraph header = new Paragraph("Manifest Report")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(20);
        document.Add(header);

        // Sub-header
        Paragraph subheader = new Paragraph($"Generated on: {DateTime.Now.ToShortDateString()}")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(15);
        document.Add(subheader);

        // Line separator and an empty space
        document.Add(new LineSeparator(new SolidLine())).Add(new Paragraph("\n"));

        // Manifest Data Table
        document.Add(await GetManifestPdfTable());

        // Closing the document
        document.Close();

        // Reset the MemoryStream position to the beginning.
        ms.Position = 0;

        // Return the stream as a PDF file.
        return new FileStreamResult(ms, "application/pdf")
        {
            FileDownloadName = "ManifestReport.pdf"
        };
    }


    private async Task<Table> GetManifestPdfTable()
    {
        Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 3, 3, 3, 4 })).UseAllAvailableWidth();

        // Adding column headers
        string[] headers = { "Manifest ID", "Member", "Trip", "Vehicle", "Notes" };
        foreach (var header in headers)
        {
            table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetBold()));
        }

        // Fetching Manifest data
        var manifests = await _context.Manifests
            .Include(m => m.Member)
            .Include(m => m.Trip)
            .Include(m => m.Vehicle)
            .ToListAsync();

        // Adding data to the table
        foreach (var manifest in manifests)
        {
            table.AddCell(new Cell().Add(new Paragraph(manifest.ManifestId.ToString())));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Member?.UserName ?? "N/A")));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Trip?.DestinationAddress ?? "N/A")));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Vehicle?.Model ?? "N/A")));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Notes ?? "No notes")));
        }

        return table;
    }



    // GET: Manifests
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Manifests.Include(m => m.Member).Include(m => m.Trip).Include(m => m.Vehicle);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: Manifests/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var manifest = await _context.Manifests
            .Include(m => m.Member)
            .Include(m => m.Trip)
            .Include(m => m.Vehicle)
            .FirstOrDefaultAsync(m => m.ManifestId == id);
        if (manifest == null)
        {
            return NotFound();
        }

        return View(manifest);
    }

    // GET: Manifests/Create
    public IActionResult Create()
    {
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
        ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId");
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId");
        return View();
    }

    // POST: Manifests/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ManifestId,MemberId,TripId,VehicleId,Notes,Created,Modified,CreatedBy,ModifiedBy")] Manifest manifest)
    {
        if (ModelState.IsValid)
        {
            _context.Add(manifest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", manifest.MemberId);
        ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", manifest.VehicleId);
        return View(manifest);
    }

    // GET: Manifests/Edit/5
    public async Task<IActionResult> Edit(int? manifestId, string? memberId)
    {
        if (manifestId == null || memberId == null)
        {
            return NotFound();
        }

        var manifest = await _context.Manifests
            .FirstOrDefaultAsync(m => m.ManifestId == manifestId && m.MemberId == memberId);
        if (manifest == null)
        {
            return NotFound();
        }
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", manifest.MemberId);
        ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", manifest.VehicleId);
        return View(manifest);
    }

    // POST: Manifests/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int manifestId, string memberId, [Bind("ManifestId,MemberId,TripId,VehicleId,Notes,Created,Modified,CreatedBy,ModifiedBy")] Manifest manifest)
    {
        if (manifestId != manifest.ManifestId || memberId != manifest.MemberId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(manifest);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManifestExists(manifest.ManifestId, manifest.MemberId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", manifest.MemberId);
        ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", manifest.VehicleId);
        return View(manifest);
    }

    // GET: Manifests/Delete/5
    public async Task<IActionResult> Delete(int? manifestId, string memberId)
    {
        if (manifestId == null || memberId == null)
        {
            return NotFound();
        }

        var manifest = await _context.Manifests
            .Include(m => m.Member)
            .Include(m => m.Trip)
            .Include(m => m.Vehicle)
            .FirstOrDefaultAsync(m => m.ManifestId == manifestId && m.MemberId == memberId);
        if (manifest == null)
        {
            return NotFound();
        }

        return View(manifest);
    }

    // POST: Manifests/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int manifestId, string memberId)
    {
        var manifest = await _context.Manifests
            .FirstOrDefaultAsync(m => m.ManifestId == manifestId && m.MemberId == memberId);
        if (manifest != null)
        {
            _context.Manifests.Remove(manifest);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool ManifestExists(int manifestId, string memberId)
    {
        return _context.Manifests.Any(e => e.ManifestId == manifestId && e.MemberId == memberId);
    }
}
