// using Application.Products.Models;
// using CommunityToolkit.Diagnostics;
// using Domain.Interfaces;
// using MediatR;
//
// namespace Application.Products.Requests;
//
// public class GetProductByIdRequest : IRequest<ProductDto>
// {
//     public Guid Id { get; set; }
// }
//
// public class GetProductByIdRequestHandler(IProductRepository repository)
//     : IRequestHandler<GetProductByIdRequest, ProductDto>
// {
//     public async Task<ProductDto> Handle(GetProductByIdRequest byIdRequest, CancellationToken cancellationToken)
//     {
//         var product = await repository.GetProductByIdAsync(byIdRequest.Id);
//         Guard.IsNotNull(product);
//         return ProductDto.From(product);
//     }
// }