using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Chinook.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    artist_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("artist__artist_id__pkey", x => x.artist_id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    last_name = table.Column<string>(maxLength: 20, nullable: false),
                    first_name = table.Column<string>(maxLength: 20, nullable: false),
                    title = table.Column<string>(maxLength: 30, nullable: true),
                    ReportsTo = table.Column<int>(nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    hire_date = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(maxLength: 70, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    state = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee__employee_id__pkey", x => x.employee_id);
                    table.ForeignKey(
                        name: "employee__reference_employee__fkey",
                        column: x => x.ReportsTo,
                        principalTable: "employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genre__genre_id__pkey", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "media_type",
                columns: table => new
                {
                    media_type_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("media_type__media_type_id__pkey", x => x.media_type_id);
                });

            migrationBuilder.CreateTable(
                name: "playlist",
                columns: table => new
                {
                    playlist_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist__playlist_id__pkey", x => x.playlist_id);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    album_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(maxLength: 160, nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("album__album_id__pkey", x => x.album_id);
                    table.ForeignKey(
                        name: "Album__reference_artist__fkey",
                        column: x => x.album_id,
                        principalTable: "artist",
                        principalColumn: "artist_id");
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(maxLength: 20, nullable: false),
                    last_name = table.Column<string>(maxLength: 20, nullable: false),
                    company = table.Column<string>(maxLength: 80, nullable: true),
                    address = table.Column<string>(maxLength: 70, nullable: true),
                    city = table.Column<string>(maxLength: 40, nullable: true),
                    state = table.Column<string>(maxLength: 40, nullable: true),
                    country = table.Column<string>(maxLength: 40, nullable: true),
                    postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    phone = table.Column<string>(maxLength: 24, nullable: true),
                    fax = table.Column<string>(maxLength: 24, nullable: true),
                    email = table.Column<string>(maxLength: 60, nullable: false),
                    SupportRepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer__customer_id__pkey", x => x.customer_id);
                    table.ForeignKey(
                        name: "customer__reference_employee__fkey",
                        column: x => x.SupportRepId,
                        principalTable: "employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "track",
                columns: table => new
                {
                    track_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 120, nullable: false),
                    AlbumId = table.Column<int>(nullable: true),
                    MediaTypeId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: true),
                    composer = table.Column<string>(maxLength: 220, nullable: true),
                    milliseconds = table.Column<int>(nullable: false),
                    bytes = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("track__track_id__pkey", x => x.track_id);
                    table.ForeignKey(
                        name: "track__reference_album_id__fkey",
                        column: x => x.AlbumId,
                        principalTable: "album",
                        principalColumn: "album_id");
                    table.ForeignKey(
                        name: "track__reference_genre_id__fkey",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "genre_id");
                    table.ForeignKey(
                        name: "track__reference_media_type_id__fkey",
                        column: x => x.MediaTypeId,
                        principalTable: "media_type",
                        principalColumn: "media_type_id");
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    invoice_date = table.Column<DateTime>(type: "date", nullable: false),
                    billing_address = table.Column<string>(maxLength: 70, nullable: true),
                    billing_city = table.Column<string>(maxLength: 40, nullable: true),
                    billing_state = table.Column<string>(maxLength: 40, nullable: true),
                    billing_country = table.Column<string>(maxLength: 40, nullable: true),
                    billing_postal_code = table.Column<string>(maxLength: 10, nullable: true),
                    total = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_id_pkey", x => x.invoice_id);
                    table.ForeignKey(
                        name: "invoice__reference_customer_id__fkey",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateTable(
                name: "playlist_track",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("playlist_track__playlist_track_id__pkey", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "playlist_track__reference_playlist__fkey",
                        column: x => x.PlaylistId,
                        principalTable: "playlist",
                        principalColumn: "playlist_id");
                    table.ForeignKey(
                        name: "playlist_track__reference_track__fkey",
                        column: x => x.TrackId,
                        principalTable: "track",
                        principalColumn: "track_id");
                });

            migrationBuilder.CreateTable(
                name: "invoice_line",
                columns: table => new
                {
                    invoice_line_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    TrackId = table.Column<int>(nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(10,2)", nullable: false, defaultValueSql: "0"),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_line__invoice_line_id__pkey", x => x.invoice_line_id);
                    table.ForeignKey(
                        name: "invoice_line__reference_invoice_id__fkey",
                        column: x => x.InvoiceId,
                        principalTable: "invoice",
                        principalColumn: "invoice_id");
                    table.ForeignKey(
                        name: "invoice_line__reference_track_id__fkey",
                        column: x => x.TrackId,
                        principalTable: "track",
                        principalColumn: "track_id");
                });

            migrationBuilder.CreateIndex(
                name: "album__artist_id__idx",
                table: "album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "customer__support_rep_id__idx",
                table: "customer",
                column: "SupportRepId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_ReportsTo",
                table: "employee",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "invoice__customer_id__idx",
                table: "invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "invoice_line__invoice_id__idx",
                table: "invoice_line",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "invoice_line__track_id__idx",
                table: "invoice_line",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "playlist_track__track_id__idx",
                table: "playlist_track",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "track__album_id__idx",
                table: "track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "track__genre_id__idx",
                table: "track",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "track__media_type_id__idx",
                table: "track",
                column: "MediaTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_line");

            migrationBuilder.DropTable(
                name: "playlist_track");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "playlist");

            migrationBuilder.DropTable(
                name: "track");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "media_type");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "artist");
        }
    }
}
