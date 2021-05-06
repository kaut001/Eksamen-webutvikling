using Microsoft.AspNetCore.Mvc;
using FindAMusicianApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FindAMusicianApi.Controllers{

    [ApiController] // må legges til for å få de egenskapene en controller skal ha
    [Route("[controller]")] // For at controlleren skal være tilgjengelig utenifra

    public class JobController : ControllerBase {
        private readonly FindAMusicianContext _context;  

        public JobController( FindAMusicianContext context){
            _context = context;
        }


        [HttpGet] // Metode som returnerer liste med alle musikkjobber/musikkoppdrag som finnes i databasen
        public async Task<IEnumerable<Jobs>> Get(){
            List<Jobs> jobsList = await _context.Jobs.ToListAsync();
            return jobsList;
        }

        [HttpGet("{id}")] // Metode som henter ut musikkjobber etter id fra databasen
        public async Task<Jobs> Get(int id){
            Jobs selectedJob = await _context.Jobs.FirstOrDefaultAsync( job => job.Id == id);
            return selectedJob;
        }

        
        [HttpPost] // Metode som legger til en ny musikkjobb/musikkoppdrag i databasen
        public async Task<Jobs> Post(Jobs newJob){
            _context.Jobs.Add( newJob );
            await _context.SaveChangesAsync();
            return newJob;
        }


        [HttpPut] // Metode som gjør det mulig å redigere en musikkjobb
        public async Task<Jobs> Put(Jobs job){
            _context.Update( job );
            await _context.SaveChangesAsync();
            return job;
        }

        [HttpDelete("{id}")] // Metode som muliggjør sletting av musikkoppdrag etter id
        public async Task<Jobs> Delete(int id){
            Jobs jobToDelete = await _context.Jobs.FirstAsync(job => job.Id == id);
            _context.Jobs.Remove(jobToDelete);
            await _context.SaveChangesAsync();
            return jobToDelete;
        }
    }

}