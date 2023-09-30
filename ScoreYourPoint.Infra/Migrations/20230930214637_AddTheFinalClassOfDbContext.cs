using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScoreYourPoint.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTheFinalClassOfDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ParticipantsAmount = table.Column<short>(type: "smallint", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Neighbor = table.Column<string>(type: "text", nullable: false),
                    Complement = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRatings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileRatings_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportPositions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SportId = table.Column<long>(type: "bigint", nullable: false),
                    PositionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SportPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportPositions_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPositionRestrictions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PositionLimitAmount = table.Column<int>(type: "integer", nullable: false),
                    Team = table.Column<char>(type: "character(1)", nullable: false),
                    SportPositionId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPositionRestrictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventPositionRestrictions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPositionRestrictions_SportPositions_SportPositionId",
                        column: x => x.SportPositionId,
                        principalTable: "SportPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEventParticipations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Team = table.Column<char>(type: "character(1)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SportPositionId = table.Column<long>(type: "bigint", nullable: true),
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEventParticipations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEventParticipations_SportPositions_SportPositionId",
                        column: x => x.SportPositionId,
                        principalTable: "SportPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserEventParticipations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPositionRestrictions_EventId",
                table: "EventPositionRestrictions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPositionRestrictions_SportPositionId",
                table: "EventPositionRestrictions",
                column: "SportPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRatings_ProfileId",
                table: "ProfileRatings",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileRatings_UserId",
                table: "ProfileRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SportPositions_PositionId",
                table: "SportPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SportPositions_SportId",
                table: "SportPositions",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventParticipations_EventId",
                table: "UserEventParticipations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventParticipations_SportPositionId",
                table: "UserEventParticipations",
                column: "SportPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventParticipations_UserId",
                table: "UserEventParticipations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPositionRestrictions");

            migrationBuilder.DropTable(
                name: "ProfileRatings");

            migrationBuilder.DropTable(
                name: "UserEventParticipations");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "SportPositions");
        }
    }
}
