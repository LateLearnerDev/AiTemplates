// using Application.Products.Models;
// using Domain.Interfaces;
// using MediatR;
//
// namespace Application.Products.Requests;
//
// public class GetProductsRequest : IRequest<List<ProductDto>>;
//
// public class GetProductsRequestHandler(IProductRepository repository)
//     : IRequestHandler<GetProductsRequest, List<ProductDto>>
// {
//     public async Task<List<ProductDto>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
//     {
//         return (await repository.GetProductsAsync())
//             .Select(ProductDto.From)
//             .ToList();
//     }
// }