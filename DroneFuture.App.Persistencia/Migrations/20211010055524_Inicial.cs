using Microsoft.EntityFrameworkCore.Migrations;

namespace DroneFuture.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperaturaZona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoDron = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoEmpaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoLlegada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pEncargadoId = table.Column<int>(type: "int", nullable: true),
                    IdEmpleado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_pEncargadoId",
                        column: x => x.pEncargadoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pEncargadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Personas_pEncargadoId",
                        column: x => x.pEncargadoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaquetePedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoFinalizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Satisfaccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pClienteId = table.Column<int>(type: "int", nullable: true),
                    pEncargadoId = table.Column<int>(type: "int", nullable: true),
                    pEstadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaquetePedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaquetePedidos_EstadoPedidos_pEstadoId",
                        column: x => x.pEstadoId,
                        principalTable: "EstadoPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaquetePedidos_Personas_pClienteId",
                        column: x => x.pClienteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaquetePedidos_Personas_pEncargadoId",
                        column: x => x.pEncargadoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_pEncargadoId",
                table: "Empresas",
                column: "pEncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaquetePedidos_pClienteId",
                table: "PaquetePedidos",
                column: "pClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PaquetePedidos_pEncargadoId",
                table: "PaquetePedidos",
                column: "pEncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_PaquetePedidos_pEstadoId",
                table: "PaquetePedidos",
                column: "pEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_pEncargadoId",
                table: "Personas",
                column: "pEncargadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "PaquetePedidos");

            migrationBuilder.DropTable(
                name: "EstadoPedidos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
