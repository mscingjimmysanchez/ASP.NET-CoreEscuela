using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCore.Migrations
{
    public partial class Alumno_mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escuelas",
                columns: table => new
                {
                    Nombre = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    AñoDeCreación = table.Column<int>(nullable: false),
                    Pais = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Dirección = table.Column<string>(nullable: true),
                    TipoEscuela = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuelas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 10, nullable: false),
                    Jornada = table.Column<int>(nullable: false),
                    Dirección = table.Column<string>(nullable: false),
                    EscuelaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Escuelas_EscuelaId",
                        column: x => x.EscuelaId,
                        principalTable: "Escuelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    CursoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    CursoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Nombre = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: false),
                    AlumnoId = table.Column<string>(nullable: true),
                    AsignaturaId = table.Column<string>(nullable: true),
                    Nota = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Asignaturas_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Escuelas",
                columns: new[] { "Id", "AñoDeCreación", "Ciudad", "Dirección", "Nombre", "Pais", "TipoEscuela" },
                values: new object[] { "70f2abf1-af34-4a1f-9306-732c6e0a9775", 2005, "Bogotá", "Avenida Siempreviva", "Platzi School", "Colombia", 1 });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Dirección", "EscuelaId", "Jornada", "Nombre" },
                values: new object[,]
                {
                    { "d7b61716-0f17-484b-b713-80a0e81773bd", "Avenida Siempreviva", "70f2abf1-af34-4a1f-9306-732c6e0a9775", 0, "101" },
                    { "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Avenida Siempreviva", "70f2abf1-af34-4a1f-9306-732c6e0a9775", 0, "201" },
                    { "1945d8cd-b28a-418e-b316-ec13c99fb421", "Avenida Siempreviva", "70f2abf1-af34-4a1f-9306-732c6e0a9775", 0, "301" },
                    { "e0299658-f08b-4096-8bb3-886a3f871817", "Avenida Siempreviva", "70f2abf1-af34-4a1f-9306-732c6e0a9775", 1, "401" },
                    { "534a6463-72fa-49e5-92de-a44fd976edfe", "Avenida Siempreviva", "70f2abf1-af34-4a1f-9306-732c6e0a9775", 1, "501" }
                });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "CursoId", "Nombre" },
                values: new object[,]
                {
                    { "00739574-fc7e-4efb-b327-8b798651fc98", "d7b61716-0f17-484b-b713-80a0e81773bd", "Felipa Diomedes Toledo" },
                    { "07e92a3f-1d82-486b-82f9-6f6429fd22e5", "e0299658-f08b-4096-8bb3-886a3f871817", "Eusebio Nicomedes Trump" },
                    { "0675ada0-cda2-481f-b5f5-be1cb3f91966", "e0299658-f08b-4096-8bb3-886a3f871817", "Eusebio Murty Ruiz" },
                    { "062ee0e6-ec94-4cfd-8581-8faf972dc041", "e0299658-f08b-4096-8bb3-886a3f871817", "Alba Diomedes Sarmiento" },
                    { "05fda2aa-9d0f-40ec-b855-f81e1b05e86a", "e0299658-f08b-4096-8bb3-886a3f871817", "Alba Rick Ruiz" },
                    { "049e017c-6f9e-4704-ad37-d21b58c7d2ae", "e0299658-f08b-4096-8bb3-886a3f871817", "Farid Murty Toledo" },
                    { "045b10bf-0ea6-4559-9cbd-d8079cd48368", "e0299658-f08b-4096-8bb3-886a3f871817", "Alvaro Teodoro Maduro" },
                    { "03ea873b-fa82-46b9-892e-2a5cc6164036", "e0299658-f08b-4096-8bb3-886a3f871817", "Felipa Diomedes Toledo" },
                    { "02dc0ac7-13ca-46d8-9a2c-e8a03434f95c", "e0299658-f08b-4096-8bb3-886a3f871817", "Donald Anabel Maduro" },
                    { "0297d59b-cda0-4f08-adc6-ee39abc2e2fc", "e0299658-f08b-4096-8bb3-886a3f871817", "Alba Rick Sarmiento" },
                    { "01a43381-d265-40ef-a538-e73d4940b5a2", "e0299658-f08b-4096-8bb3-886a3f871817", "Alba Anabel Toledo" },
                    { "06a86bbd-1ed4-4bc2-b811-554feb8534ed", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Nicolás Rick Uribe" },
                    { "060951cd-2942-4a11-b881-acc789bed320", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Felipa Anabel Sarmiento" },
                    { "059be249-ebfd-49f7-b768-1f0537e618d0", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Alba Silvana Ruiz" },
                    { "04eb25f4-83d2-4649-8406-00504f89223b", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Farid Diomedes Sarmiento" },
                    { "03a3d0ea-9c84-45fd-bd9d-1cc7ef24a50b", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Alvaro Nicomedes Trump" },
                    { "03a30d9e-86c8-4750-b5a9-553982c2d3cd", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Alvaro Nicomedes Ruiz" },
                    { "0330cefb-9c08-4090-9697-908110e22f3d", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Donald Diomedes Ruiz" },
                    { "08b8834f-0915-43a8-96d6-3ffcf5b8d443", "e0299658-f08b-4096-8bb3-886a3f871817", "Farid Nicomedes Maduro" },
                    { "020ea134-5c38-4871-b669-e904a554d8e2", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Felipa Rick Ruiz" },
                    { "099fc324-6866-4b2c-8f40-e8d87f627313", "e0299658-f08b-4096-8bb3-886a3f871817", "Alvaro Rick Uribe" },
                    { "0a20af6a-dd4f-4148-8f44-09a22fdd54f1", "e0299658-f08b-4096-8bb3-886a3f871817", "Nicolás Teodoro Sarmiento" },
                    { "0a92a596-d559-44b6-b379-36216b68c6d7", "534a6463-72fa-49e5-92de-a44fd976edfe", "Eusebio Teodoro Uribe" },
                    { "08d4dc0d-7e2a-4075-9033-67a90d1297ff", "534a6463-72fa-49e5-92de-a44fd976edfe", "Eusebio Diomedes Ruiz" },
                    { "07c6040f-e947-4557-a4ba-0e1485c98612", "534a6463-72fa-49e5-92de-a44fd976edfe", "Nicolás Silvana Sarmiento" },
                    { "05e2a698-2f5b-475b-9372-2369788bcfc2", "534a6463-72fa-49e5-92de-a44fd976edfe", "Donald Teodoro Toledo" },
                    { "04ea40f1-8b8c-4cb5-8c22-0d86f0205dd8", "534a6463-72fa-49e5-92de-a44fd976edfe", "Donald Anabel Sarmiento" },
                    { "04955a7d-a8fe-4508-a310-601fad3e60fb", "534a6463-72fa-49e5-92de-a44fd976edfe", "Farid Murty Sarmiento" },
                    { "046804e2-f9f6-4fc7-bee9-aa6c51ef3d58", "534a6463-72fa-49e5-92de-a44fd976edfe", "Eusebio Silvana Trump" },
                    { "04525fff-89e0-4efc-9920-db81544cd0cf", "534a6463-72fa-49e5-92de-a44fd976edfe", "Alba Anabel Sarmiento" },
                    { "044b89ef-fd97-46f9-b2c7-c7ce12945e34", "534a6463-72fa-49e5-92de-a44fd976edfe", "Eusebio Rick Herrera" },
                    { "041eb4c0-d245-4400-b66f-5fd20594c1b4", "534a6463-72fa-49e5-92de-a44fd976edfe", "Alba Teodoro Ruiz" },
                    { "038b5c0a-b82b-4ac5-8895-7dcea2b7b1c4", "534a6463-72fa-49e5-92de-a44fd976edfe", "Farid Murty Toledo" },
                    { "036018d5-1d48-49cb-ba30-bb7fd968e638", "534a6463-72fa-49e5-92de-a44fd976edfe", "Nicolás Anabel Ruiz" },
                    { "035fa72e-24f3-4973-ac16-e1d015be37ce", "534a6463-72fa-49e5-92de-a44fd976edfe", "Alba Anabel Ruiz" },
                    { "019b3dd0-3042-4b6c-8774-f6e6e54d8ce3", "534a6463-72fa-49e5-92de-a44fd976edfe", "Eusebio Anabel Trump" },
                    { "00f0b2cb-d6e8-4983-9ef5-827e9bdae248", "534a6463-72fa-49e5-92de-a44fd976edfe", "Felipa Diomedes Ruiz" },
                    { "0ca0117b-5c97-4c86-8c10-e5b57bdd5b97", "e0299658-f08b-4096-8bb3-886a3f871817", "Farid Rick Toledo" },
                    { "0c177f1e-d98c-4cec-94ff-e65e73c73db0", "e0299658-f08b-4096-8bb3-886a3f871817", "Alba Nicomedes Uribe" },
                    { "09a2d7a6-523e-4483-98cb-54ddbfc4aedd", "e0299658-f08b-4096-8bb3-886a3f871817", "Farid Murty Uribe" },
                    { "01c99589-cd47-42c9-8a48-7379b1455195", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Alvaro Teodoro Toledo" },
                    { "053b9232-5c98-4cf8-82d8-533c863169bf", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Nicolás Anabel Trump" },
                    { "0090af8f-c5c9-49ce-9322-b50c2aae98a3", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Eusebio Murty Trump" },
                    { "04128daf-33a4-4f7e-9c2e-19cd3382e128", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Alvaro Anabel Toledo" },
                    { "03f1e4d6-f668-40e0-9436-f88f7d5378d3", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Nicolás Nicomedes Toledo" },
                    { "03a43d82-7a6b-45f3-bd65-acd927c8492c", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Felipa Nicomedes Herrera" },
                    { "02d94ab5-1a4d-44f2-acc0-3b0788494d65", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Donald Murty Herrera" },
                    { "016aebdb-a817-4987-97ac-e3323ef6e901", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Alba Murty Maduro" },
                    { "01807352-078b-4ce8-8c7b-1ec3972b5154", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Felipa Murty Ruiz" },
                    { "0160e946-adc3-403c-a460-b1b0587dc0c4", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Alba Anabel Sarmiento" },
                    { "0061fd49-d5a7-4d05-937e-7d8b6bb0f470", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Alba Rick Ruiz" },
                    { "042ac2c1-0c6c-4ae3-9ba6-5d1834e56adc", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Farid Anabel Herrera" },
                    { "0ac5b512-546c-4880-ba1b-63140786bc60", "d7b61716-0f17-484b-b713-80a0e81773bd", "Eusebio Rick Toledo" },
                    { "07a16b3f-d342-482f-95de-d3b3e4749a34", "d7b61716-0f17-484b-b713-80a0e81773bd", "Farid Nicomedes Toledo" },
                    { "06d5887d-e457-464a-976d-750109245515", "d7b61716-0f17-484b-b713-80a0e81773bd", "Donald Silvana Sarmiento" },
                    { "04246fb2-6c53-4872-9dae-c3826f176932", "d7b61716-0f17-484b-b713-80a0e81773bd", "Donald Silvana Herrera" },
                    { "03f4430a-0eb6-4110-a97f-b17fdd14bcaf", "d7b61716-0f17-484b-b713-80a0e81773bd", "Felipa Freddy Uribe" },
                    { "02ebae21-6cde-4468-a02a-392f0889ec6f", "d7b61716-0f17-484b-b713-80a0e81773bd", "Donald Rick Maduro" },
                    { "02e8a38c-7c27-4eb3-898f-fd241e9ab27c", "d7b61716-0f17-484b-b713-80a0e81773bd", "Eusebio Anabel Toledo" },
                    { "0125201d-c7ed-447b-b5f5-fba207690e8a", "d7b61716-0f17-484b-b713-80a0e81773bd", "Felipa Diomedes Uribe" },
                    { "00aee35e-dc91-468d-8939-a938ce55e5dc", "d7b61716-0f17-484b-b713-80a0e81773bd", "Nicolás Nicomedes Toledo" },
                    { "087ff771-ba6c-4398-a2dc-e51bb4d537f7", "d7b61716-0f17-484b-b713-80a0e81773bd", "Alvaro Nicomedes Herrera" },
                    { "045f7899-91bd-4ee8-8dd4-3626f0b6fc74", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Donald Silvana Ruiz" },
                    { "02bf7184-ac5f-4b00-abc4-f17847cd8c96", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Alvaro Diomedes Sarmiento" },
                    { "049675f6-55bc-4a71-9e8d-90f951762aa5", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Felipa Silvana Sarmiento" },
                    { "04ad572b-216f-4706-b97f-36e2e697c50d", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Nicolás Silvana Trump" },
                    { "05a757bc-87b8-4652-8e1f-f98d7892a708", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Alvaro Silvana Maduro" },
                    { "066caee8-512e-4d7b-95d2-a0721e0724e3", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Alvaro Anabel Trump" },
                    { "06cb97a5-b7a8-4b6c-88dc-5f1a0738075e", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Donald Teodoro Toledo" },
                    { "04720fd3-feac-4602-9c60-68b855f0a3ee", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Felipa Silvana Ruiz" },
                    { "09b8cb48-e9dc-4f95-8d1c-6b8364073880", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Nicolás Murty Herrera" },
                    { "004a2909-77f6-4055-b1d5-76fc077c5418", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Farid Murty Herrera" },
                    { "076e28a4-50af-450c-8630-9bf3c28b852c", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Felipa Teodoro Trump" }
                });

            migrationBuilder.InsertData(
                table: "Asignaturas",
                columns: new[] { "Id", "CursoId", "Nombre" },
                values: new object[,]
                {
                    { "8ae09880-1df3-4b09-9515-a51a74c70c5f", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Matemáticas" },
                    { "f626072a-d435-4e40-8820-bcfbba2dab67", "534a6463-72fa-49e5-92de-a44fd976edfe", "Ciencias Naturales" },
                    { "e003138c-8f23-40a2-b988-dc7090d342bd", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Educación Física" },
                    { "260dc65b-4745-449f-8f28-17b71079b112", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Programación" },
                    { "05418926-cd47-4970-acdb-72568663a411", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Ciencias Naturales" },
                    { "a7feff0f-3d83-42d9-816c-19e85c9b4407", "534a6463-72fa-49e5-92de-a44fd976edfe", "Matemáticas" },
                    { "08388103-c881-40ca-acc5-ff693f7d797a", "534a6463-72fa-49e5-92de-a44fd976edfe", "Educación Física" },
                    { "29e1ac8e-ce34-4166-a5a2-87db1fd337d6", "534a6463-72fa-49e5-92de-a44fd976edfe", "Castellano" },
                    { "e9d27416-572e-4669-b06b-ad0642559b6b", "3c61ce53-0d01-4a1b-ab49-4f74f4719df5", "Castellano" },
                    { "fbfbf512-793e-420d-8984-4e40cc1de477", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Matemáticas" },
                    { "e89c0ba5-539f-475a-a88d-ca7a5ebfd917", "d7b61716-0f17-484b-b713-80a0e81773bd", "Castellano" },
                    { "f49ddfc6-9174-49e6-b54a-433c77e77fa1", "d7b61716-0f17-484b-b713-80a0e81773bd", "Educación Física" },
                    { "df79d182-5640-4a53-8f12-5f75ee17a852", "d7b61716-0f17-484b-b713-80a0e81773bd", "Ciencias Naturales" },
                    { "b697a4a8-e8b8-4694-a073-0dfef05f120c", "d7b61716-0f17-484b-b713-80a0e81773bd", "Programación" },
                    { "ec2c0b01-b3d4-4ff8-a3bc-20932dbbdafa", "e0299658-f08b-4096-8bb3-886a3f871817", "Programación" },
                    { "bec79c3c-cbcc-4acb-b043-3b9d46d676a0", "e0299658-f08b-4096-8bb3-886a3f871817", "Ciencias Naturales" },
                    { "0f82b37a-f754-4512-a6c9-07b7d1884bb9", "e0299658-f08b-4096-8bb3-886a3f871817", "Castellano" },
                    { "58320dd3-341b-4289-ae0a-74f1a8bbb215", "e0299658-f08b-4096-8bb3-886a3f871817", "Educación Física" },
                    { "5583ca38-8766-497b-95b4-a6d83d0dc50a", "e0299658-f08b-4096-8bb3-886a3f871817", "Matemáticas" },
                    { "6c819690-3f91-40e4-9f70-223007951029", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Educación Física" },
                    { "3bb9dc71-8bb1-4a25-a201-6261b95ea9b1", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Castellano" },
                    { "490038e7-2228-44ee-9f69-01049f36bc09", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Ciencias Naturales" },
                    { "41553e3f-30f1-40d4-a23e-5e538025a263", "1945d8cd-b28a-418e-b316-ec13c99fb421", "Programación" },
                    { "92441002-fe0a-4532-b45f-f94b39fdef0f", "d7b61716-0f17-484b-b713-80a0e81773bd", "Matemáticas" },
                    { "1a55ba09-e3af-47fa-b6f7-af1ecead431c", "534a6463-72fa-49e5-92de-a44fd976edfe", "Programación" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CursoId",
                table: "Alumnos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CursoId",
                table: "Asignaturas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_EscuelaId",
                table: "Cursos",
                column: "EscuelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_AlumnoId",
                table: "Evaluaciones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_AsignaturaId",
                table: "Evaluaciones",
                column: "AsignaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Escuelas");
        }
    }
}
