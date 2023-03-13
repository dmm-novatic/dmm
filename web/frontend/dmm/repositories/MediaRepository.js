import Repository, { baseUrl } from './Repository';
import Utils from '~/utils/Utils';
class MediaRespository {
    async getBannersBySlug(payload) {
        try {
            const endPoint = `systemConfig/api/Search?keyword=${payload}`;
            const response = await Repository.get(`${baseUrl}/${endPoint}`);
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }

    async getPromotionsBySlug(payload) {
        try {
            const endPoint = `systemConfig/api/Search?keyword=${payload}`;
            const response = await Repository.get(`${baseUrl}/${endPoint}`);
            const data = Utils.handleResponse(response);
            return data;
        } catch (error) {
            Utils.handleError(error);
            return null;
        }
    }
}

export default new MediaRespository();
