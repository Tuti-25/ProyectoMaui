﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectoMauiAPI.Migrations
{
    /// <inheritdoc />
    public partial class NuevaBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCaso",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEstado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCaso", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.IdGrupo);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DescripcionRol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Severidades",
                columns: table => new
                {
                    IdSeveridad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSeveridad = table.Column<int>(type: "int", nullable: true),
                    DescripcionSeveridad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Severidades", x => x.IdSeveridad);
                });

            migrationBuilder.CreateTable(
                name: "TipoMensajes",
                columns: table => new
                {
                    IdTipoMensaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatoMensaje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMensajes", x => x.IdTipoMensaje);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoCasa = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ApellidoUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CorreoUsuario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TelefonoUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CedulaUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContrasenaUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    IdAgente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAgente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ApellidoAgente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TelefonoAgente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CedulaAgente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.IdAgente);
                    table.ForeignKey(
                        name: "FK_Agentes_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioGrupos",
                columns: table => new
                {
                    IdUsuarioGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdGrupo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioGrupos", x => x.IdUsuarioGrupo);
                    table.ForeignKey(
                        name: "FK_UsuarioGrupos_Grupos_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupos",
                        principalColumn: "IdGrupo");
                    table.ForeignKey(
                        name: "FK_UsuarioGrupos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    IdCaso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionCaso = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdAgente = table.Column<int>(type: "int", nullable: false),
                    IdSeveridad = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.IdCaso);
                    table.ForeignKey(
                        name: "FK_Casos_Agentes_IdAgente",
                        column: x => x.IdAgente,
                        principalTable: "Agentes",
                        principalColumn: "IdAgente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casos_EstadosCaso_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "EstadosCaso",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casos_Severidades_IdSeveridad",
                        column: x => x.IdSeveridad,
                        principalTable: "Severidades",
                        principalColumn: "IdSeveridad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Casos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    IdMensaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCaso = table.Column<int>(type: "int", nullable: true),
                    IdGrupo = table.Column<int>(type: "int", nullable: true),
                    IdTipoMensaje = table.Column<int>(type: "int", nullable: false),
                    DescripcionMensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaMensaje = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.IdMensaje);
                    table.ForeignKey(
                        name: "FK_Mensajes_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "IdCaso");
                    table.ForeignKey(
                        name: "FK_Mensajes_Grupos_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupos",
                        principalColumn: "IdGrupo");
                    table.ForeignKey(
                        name: "FK_Mensajes_TipoMensajes_IdTipoMensaje",
                        column: x => x.IdTipoMensaje,
                        principalTable: "TipoMensajes",
                        principalColumn: "IdTipoMensaje",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensajes_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archivos",
                columns: table => new
                {
                    IdArchivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMensaje = table.Column<int>(type: "int", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RutaArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoArchivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivos", x => x.IdArchivo);
                    table.ForeignKey(
                        name: "FK_Archivos_Mensajes_IdMensaje",
                        column: x => x.IdMensaje,
                        principalTable: "Mensajes",
                        principalColumn: "IdMensaje",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    IdNotificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdMensaje = table.Column<int>(type: "int", nullable: true),
                    IdCaso = table.Column<int>(type: "int", nullable: true),
                    TipoNotificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.IdNotificacion);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Casos_IdCaso",
                        column: x => x.IdCaso,
                        principalTable: "Casos",
                        principalColumn: "IdCaso");
                    table.ForeignKey(
                        name: "FK_Notificaciones_Mensajes_IdMensaje",
                        column: x => x.IdMensaje,
                        principalTable: "Mensajes",
                        principalColumn: "IdMensaje");
                    table.ForeignKey(
                        name: "FK_Notificaciones_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentes_IdRol",
                table: "Agentes",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Archivos_IdMensaje",
                table: "Archivos",
                column: "IdMensaje");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_IdAgente",
                table: "Casos",
                column: "IdAgente");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_IdEstado",
                table: "Casos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_IdSeveridad",
                table: "Casos",
                column: "IdSeveridad");

            migrationBuilder.CreateIndex(
                name: "IX_Casos_IdUsuario",
                table: "Casos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdCaso",
                table: "Mensajes",
                column: "IdCaso");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdGrupo",
                table: "Mensajes",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdTipoMensaje",
                table: "Mensajes",
                column: "IdTipoMensaje");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_IdUsuario",
                table: "Mensajes",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdCaso",
                table: "Notificaciones",
                column: "IdCaso");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdMensaje",
                table: "Notificaciones",
                column: "IdMensaje");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdUsuario",
                table: "Notificaciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGrupos_IdGrupo",
                table: "UsuarioGrupos",
                column: "IdGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGrupos_IdUsuario",
                table: "UsuarioGrupos",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivos");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "UsuarioGrupos");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "TipoMensajes");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropTable(
                name: "EstadosCaso");

            migrationBuilder.DropTable(
                name: "Severidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
