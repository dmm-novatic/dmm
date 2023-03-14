import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';

class CollectionRepository {
    async getProductsByCollectionSlug(slug) {
        try {
            if (
                slug === undefined ||
                slug.id === undefined ||
                slug.pageIndex === undefined ||
                slug.pageSize === undefined
            ) {
                return null;
            }
            const response = await Repository.get(
                `${baseUrl}/product/api/list/categoryId?cateID=` +
                    slug.id +
                    `&pageIndex=${slug.pageIndex}&pageSize=${slug.pageSize}`
            );
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }

    async getProductsByCategorySlug(slug) {
        const reponse = await Repository.get(
            `${baseUrl}/product-categories?slug_in=${slug}`
        )
            .then((response) => {
                if (response.data && response.data.length > 0) {
                    return { items: response.data[0].products };
                } else {
                    return null;
                }
                return response.data;
            })
            .catch((error) => {
                console.log(JSON.stringify(error));
                return null;
            });
        return reponse;
    }
    async getProductByShopId(slug, pageIndex, pageSize) {
        try {
            const response = await Repository.get(
                `${baseUrl}/product/api/list/FilterByShop?ShopID=${slug}&pageIndex=${pageIndex}&pageSize=${pageSize}`,
                slug
            );
            return response.data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}

export default new CollectionRepository();
