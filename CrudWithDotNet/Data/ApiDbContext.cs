using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudWithDotNet.Models;

namespace CrudWithDotNet.Data;

public class ApiDbContext : DbContext
{

public DbSet<Team> Teams {get; set;}

public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options){

}

}