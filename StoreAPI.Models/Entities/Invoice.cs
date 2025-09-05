using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreAPI.Models.Entities
{
    public class Invoice
    {
        [Key] // Clave primaria
        public int Id { get; set; }

        // Relación con Order (FK)
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; } // Número de factura único

        [Required]
        public DateTime IssueDate { get; set; } // Fecha de emisión

        public DateTime? DueDate { get; set; } // Fecha de vencimiento opcional

        [Column(TypeName = "decimal(18,2)")]
        public double Subtotal { get; set; } // Subtotal

        [Column(TypeName = "decimal(18,2)")]
        public double Tax { get; set; } // Impuesto

        [Column(TypeName = "decimal(18,2)")]
        public double Total { get; set; } // Total

        [Required]
        [MaxLength(5)]
        public string Currency { get; set; } // MXN, USD, etc.

        public bool IsPaid { get; set; } = false; // Pagada o no

        public DateTime? PaymentDate { get; set; } // Fecha de pago opcional

        [Required]
        [MaxLength(150)]
        public string BillingName { get; set; } // Nombre del cliente

        [MaxLength(250)]
        public string BillingAddress { get; set; } // Dirección del cliente

        [EmailAddress]
        [MaxLength(150)]
        public string BillingEmail { get; set; } // Email del cliente

        [MaxLength(20)]
        public string TaxId { get; set; } // RFC/NIF/VAT

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Fecha creación

        public DateTime? UpdatedAt { get; set; } // Fecha última modificación
    }
}


/*
Implementar la entidad Invoice (factura) en un proyecto .NET (Web API con Entity Framework Core), crear la migración y exponer endpoints para consultar y crear facturas.




Crear la entidad Invoice con las propiedades mínimas:


Id (int, PK)

OrderId (int, FK a Order)

InvoiceNumber (string, requerido, único)

IssueDate (DateTime, requerido)

DueDate (DateTime?, opcional)

Subtotal (double)

Tax (double)

Total (double)

Currency (string, requerido, por ejemplo “MXN”)

IsPaid (bool)

PaymentDate (DateTime?, opcional)

BillingName (string, requerido)

BillingAddress (string, opcional)

BillingEmail (string, email válido, opcional)

TaxId (string, opcional – RFC/NIF/VAT)

CreatedAt (DateTime, set automático)

UpdatedAt (DateTime?, set automático)

Agregar DbSet<Invoice> al DbContext y la relación con Order.

Crear y aplicar la migración de EF Core.

Crear un controlador API InvoicesController con:


GET /api/invoices → lista todas las facturas (con filtros opcionales orderId, isPaid).

GET /api/invoices/{id} → obtiene una factura por Id.

POST /api/invoices → crea una nueva factura (valida datos, calcula Total si no viene).

Subir repositorio de git
*/