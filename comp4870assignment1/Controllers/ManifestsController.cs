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
using System.Security.Claims;
using iText.IO.Image;

namespace assignment1.Controllers;

[Authorize(Roles = "Admin, Owner")]
public class ManifestsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public ManifestsController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<IActionResult> GeneratePDFReport()
    {
        var ms = new MemoryStream();

        // Create a PdfWriter instance directing it to write to the MemoryStream.
        var writer = new PdfWriter(ms);
        var pdfDoc = new PdfDocument(writer);
        var document = new Document(pdfDoc, PageSize.A4);
        writer.SetCloseStream(false);

        // Add logo
        string logoPath = System.IO.Path.Combine(_env.WebRootPath, "images/logo.png");
        ImageData logoData = ImageDataFactory.Create(logoPath);
        Image logo = new Image(logoData).SetWidth(100).SetHeight(100);
        document.Add(logo);

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
        string[] headers = { "Manifest ID", "Member", "Destination Address", "Meeting Address", "Notes" };
        foreach (var header in headers)
        {
            table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetBold()));
        }

        // Fetching Manifest data
        var manifests = await _context.Manifests
            .Include(m => m.Member)
            .Include(m => m.Trip)
            .ToListAsync();

        // Adding data to the table
        foreach (var manifest in manifests)
        {
            table.AddCell(new Cell().Add(new Paragraph(manifest.ManifestId.ToString())));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Member?.UserName ?? "N/A")));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Trip?.DestinationAddress ?? "N/A")));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Trip?.MeetingAddress ?? "N/A")));
            table.AddCell(new Cell().Add(new Paragraph(manifest.Notes ?? "No notes")));
        }

        return table;
    }

    public async Task<IActionResult> TripPdf()
    {
        // Retrieve the ID of the current logged-in user
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        IQueryable<Manifest> query;

        // Check if the current user is an admin
        if (User.IsInRole("Admin"))
        {
            // Admins get to see all manifests
            query = _context.Manifests.Include(m => m.Member).Include(m => m.Trip);
        }
        else
        {
            // Regular users see only their manifests
            query = _context.Manifests
                .Include(m => m.Member)
                .Include(m => m.Trip)
                .Where(m => m.MemberId == userId);
        }

        var manifests = await query.ToListAsync();

        // Pass the list of manifests to the view
        return View(manifests);
    }


    public async Task<IActionResult> GenerateTripPDFReport(int manifestId)
    {
        var ms = new MemoryStream();

        // Create a PdfWriter instance directing it to write to the MemoryStream.
        var writer = new PdfWriter(ms);
        var pdfDoc = new PdfDocument(writer);
        var document = new Document(pdfDoc, PageSize.A4);
        writer.SetCloseStream(false);

        // Retrieve the Manifest including its Trip
        var manifest = await _context.Manifests
            .Include(m => m.Trip)
            .ThenInclude(t => t!.Vehicle) // Assuming you want vehicle details as well
            .Include(m => m!.Member)
            .Where(m => m.ManifestId == manifestId)
            .ToListAsync();

        if (manifest == null)
        {
            return NotFound();
        }

        // Add logo
        string logoPath = System.IO.Path.Combine(_env.WebRootPath, "images/logo.png");
        ImageData logoData = ImageDataFactory.Create(logoPath);
        Image logo = new Image(logoData).SetWidth(100).SetHeight(100);
        document.Add(logo);

        // Header
        Paragraph header = new Paragraph("Trip Report")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(20);
        document.Add(header);

        // Sub-header
        Paragraph subheader = new Paragraph($"Generated on: {DateTime.Now.ToShortDateString()}")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(15);
        document.Add(subheader);

        document.Add(new LineSeparator(new SolidLine())).Add(new Paragraph("\n"));

        // Adding Trip Details
        document.Add(new Paragraph($"Trip ID: {manifest[0].TripId}"));
        document.Add(new Paragraph($"Destination Address: {manifest[0].Trip?.DestinationAddress ?? "N/A"}"));
        document.Add(new Paragraph($"Meeting Address: {manifest[0].Trip?.MeetingAddress ?? "N/A"}"));
        document.Add(new Paragraph($"Date: {manifest[0].Trip?.Date?.ToString("d") ?? "N/A"}"));
        document.Add(new Paragraph($"Time: {manifest[0].Trip?.Time?.ToString("t") ?? "N/A"}"));

        // Optionally, add vehicle details and any other relevant information
        document.Add(new LineSeparator(new SolidLine())).Add(new Paragraph("\n"));
        document.Add(new Paragraph("Passengers")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(15));
        for (int i = 0; i < manifest.Count; i++)
        {
            document.Add(new Paragraph($"Name: {manifest[i].Member?.FirstName} {manifest[i].Member?.LastName ?? "N/A"}")).SetFontSize(10);
            document.Add(new Paragraph($"Email: {manifest[i].Member?.Email ?? "N/A"}")).SetFontSize(10);
            document.Add(new LineSeparator(new DashedLine())).Add(new Paragraph("\n"));
        }

        // Closing the document
        document.Close();

        // Reset the MemoryStream position to the beginning.
        ms.Position = 0;

        // Return the stream as a PDF file
        return new FileStreamResult(ms, "application/pdf")
        {
            FileDownloadName = $"TripReport_{manifest[0].TripId}.pdf"
        };
    }

    // GET: Manifests
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Manifests.Include(m => m.Member).Include(m => m.Trip);
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
            .FirstOrDefaultAsync(m => m.ManifestId == id);
        if (manifest == null)
        {
            return NotFound();
        }

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
        ViewData["TripId"] = new SelectList(_context.Trips
                .Select(t => new { t.TripId, Description = "[" + t.TripId + "] Destination: " + t.DestinationAddress }),
                "TripId", "Description");
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
