using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ship.Migrations
{
    public partial class w : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliverySpeed",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShipSpeed = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySpeed", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recipient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RName = table.Column<string>(maxLength: 30, nullable: false),
                    RPhone = table.Column<string>(nullable: true),
                    Rddress = table.Column<string>(maxLength: 30, nullable: false),
                    DateReceived = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SName = table.Column<string>(maxLength: 30, nullable: false),
                    SAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WB = table.Column<string>(maxLength: 30, nullable: false),
                    SenderID = table.Column<int>(nullable: false),
                    RecipientID = table.Column<int>(nullable: false),
                    DateShipped = table.Column<DateTime>(nullable: false),
                    DateDelivered = table.Column<DateTime>(nullable: false),
                    DeliverySpeedID = table.Column<int>(nullable: false),
                    Weight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shipment_DeliverySpeed_DeliverySpeedID",
                        column: x => x.DeliverySpeedID,
                        principalTable: "DeliverySpeed",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipment_Recipient_RecipientID",
                        column: x => x.RecipientID,
                        principalTable: "Recipient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipment_Sender_SenderID",
                        column: x => x.SenderID,
                        principalTable: "Sender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_DeliverySpeedID",
                table: "Shipment",
                column: "DeliverySpeedID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_RecipientID",
                table: "Shipment",
                column: "RecipientID");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_SenderID",
                table: "Shipment",
                column: "SenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "DeliverySpeed");

            migrationBuilder.DropTable(
                name: "Recipient");

            migrationBuilder.DropTable(
                name: "Sender");
        }
    }
}
