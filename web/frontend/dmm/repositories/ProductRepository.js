import Repository, { baseUrl, serializeQuery } from './Repository';
import Utils from '~/utils/Utils';
class ProductRepository {
    async getRecords(params) {
        const reponse = await Repository.get(
            `${baseUrl}/products?${serializeQuery(params)}`
        )
            .then((response) => {
                return response.data;
            })
            .catch((error) => ({ error: JSON.stringify(error) }));
        return reponse;
    }
    async getSearchRecords(params) {
        try {
            const response = await Repository.get(
                `${baseUrl}/product/api/list/SearchbyCategoryIdAndName?${serializeQuery(params)}`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getProducts() {
        const reponse = await Repository.get(`${baseUrl}/product/api/list`)
            .then((response) => {
                if (response.data?.data && response.data.data?.length > 0) {
                    return response.data.data;
                } else {
                    return null;
                }
            })
            .catch((error) => {
                return null;
            });
        return reponse;
    }
    async getProductDetail(id) {
        try {
            const response = await Repository.get(
                `${baseUrl}/productMeta/api/listProductMeta/ProductId?productId=${id}`
            );
            const data = Utils.handleResponse(response);
            return data[0];
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getBrands() {
        const reponse = await Repository.get(`${baseUrl}/brands`)
            .then((response) => {
                return response.data;
            })
            .catch((error) => ({ error: JSON.stringify(error) }));
        return reponse;
    }
    async getAllBrand() {
        try {
            const response = await Repository.get(
                `${baseUrl}/productBrand/api/list`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
    async getProductCategories() {
        const reponse = await Repository.get(
            `${baseUrl}/productCategory/api/list`
        )
            .then((response) => {
                return response.data;
            })
            .catch((error) => ({ error: JSON.stringify(error) }));
        return reponse;
    }

    async getTotalRecords() {
        const reponse = await Repository.get(`${baseUrl}/products/count`)
            .then((response) => {
                return response.data;
            })
            .catch((error) => ({ error: JSON.stringify(error) }));
        return reponse;
    }

    async getProductsById(payload) {
        try {
            if (payload === undefined) {
                return null;
            }
            const reponse = await Repository.get(
                `${baseUrl}/product/api/detail/${payload}`
            );

            const data = Utils.handleResponse(reponse);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }

    async getProductsByCategory(payload, pageIndex, pageSize) {
        try {
            if (
                payload === undefined ||
                pageIndex === undefined ||
                pageSize === undefined
            ) {
                return null;
            }
            const reponse = await Repository.get(
                `${baseUrl}/product/api/list/categoryId?cateID=${payload}&pageIndex=${pageIndex}&pageSize=${pageSize}`
            );
            return reponse.data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }

    async getProductsByBrand(payload, pageIndex, pageSize) {
        try {
            if (
                payload === undefined ||
                pageIndex === undefined ||
                pageSize === undefined
            ) {
                return null;
            }
            const reponse = await Repository.get(
                `${baseUrl}/product/api/list/BrandId?brandId=${payload}&pageIndex=${pageIndex}&pageSize=${pageSize}`
            );
            return reponse.data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }

    async getProductsByIds(payload) {
        const endPoint = `${baseUrl}/products?${payload}`;
        const reponse = await Repository.get(endPoint)
            .then((response) => {
                if (response.data && response.data.length > 0) {
                    return response.data;
                } else {
                    return null;
                }
            })
            .catch((error) => {
                console.log(JSON.stringify(error));
                return null;
            });
        return reponse;
    }
}

export default new ProductRepository();
