﻿using Core.Extensions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels;

public class UpdateProductViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid Id { get; set; }

    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres")]
    [Display(Name = "Nome")]
    public string? Name { get; set; }

    [StringLength(300, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres")]
    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    [Currency]
    [Range(1, 9999, ErrorMessage = "O campo {0} deve ser maior que {1} e menor que {2}")]
    [Display(Name = "Preço")]
    public decimal? Price { get; set; }

    [Range(1, 9999, ErrorMessage = "O campo {0} deve ser maior que {1} e menor que {2}")]
    [Display(Name = "Quantidade")]
    public int? Stock { get; set; }
}

public class CreateProductViewModel
{
    public Guid CategoryId { get; set; }

    [Display(Name = "Imagem")]
    public IFormFile? UploadImage { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(300, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres")]
    [Display(Name = "Descrição")]
    public string Description { get; set; }

    [Currency]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    //[Range(1.01, 9999.00, ErrorMessage = "O campo {0} deve ser maior que {1} e menor que {2}")]
    [Display(Name = "Preço")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, 9999, ErrorMessage = "O campo {0} deve ser maior que {1} e menor que {2}")]
    [Display(Name = "Quantidade")]
    public int Stock { get; set; }
}