import React from 'react';
import ThumbnailDefault from '~/components/elements/detail/thumbnail/ThumbnailDefault';
import ModuleDetailTopInformation from '~/components/elements/detail/modules/ModuleDetailTopInformation';
import ModuleProductDetailDescription from '~/components/elements/detail/modules/ModuleProductDetailDescription';
import ModuleDetailShoppingActions from '~/components/elements/detail/modules/ModuleDetailShoppingActions';
import ModuleProductDetailSpecification from '~/components/elements/detail/modules/ModuleProductDetailSpecification';
import ModuleProductDetailSharing from '~/components/elements/detail/modules/ModuleProductDetailSharing';
import ModuleDetailActionsMobile from '~/components/elements/detail/modules/ModuleDetailActionsMobile';
import { useState, useEffect } from 'react';
import ProductRepository from '~/repositories/ProductRepository';
const ProductDetailQuickView = ({ product }) => {
    const [dataDetail, setDataDetail] = useState(null);
    const getProductDetail = async () => {
        const result = await ProductRepository.getProductDetail(product.id);
        if (result) {
            setDataDetail(result);
        }
    };
    useEffect(() => {
        getProductDetail();
    }, [product]);
    return (
        <div className="ps-product--detail ps-product--quickview">
            <div className="ps-product__header">
                {dataDetail !== null && (
                    <ThumbnailDefault
                        productDetail={dataDetail}
                        vertical={false}
                    />
                )}
                <div className="ps-product__info">
                    <ModuleDetailTopInformation product={product} />
                    <ModuleProductDetailDescription product={product} />
                    <ModuleDetailShoppingActions
                        product={product}
                        extended={true}
                    />
                    <ModuleProductDetailSpecification />
                    <ModuleProductDetailSharing />
                    <ModuleDetailActionsMobile />
                </div>
            </div>
        </div>
    );
};

export default ProductDetailQuickView;
