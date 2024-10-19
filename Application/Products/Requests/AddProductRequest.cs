// using CommunityToolkit.Diagnostics;
// using Domain.Entities;
// using Domain.Interfaces;
// using MediatR;
//
// namespace Application.Products.Requests;
//
// public class AddProductRequest : IRequest<Guid>
// {
//     public string Name { get; set; } = null!;
//     public decimal Price { get; set; }
// }
//
// public class AddProductRequestHandler(IProductRepository repository) : IRequestHandler<AddProductRequest, Guid>
// {
//     public async Task<Guid> Handle(AddProductRequest request, CancellationToken cancellationToken)
//     {
//         Guard.IsNotNull(request.Name);
//         var productId = await repository.AddProductAsync(Product.Create(request.Name, request.Price));
//         return productId;
//     }
// }