import React from 'react';
import ThumbnailDefault from '~/components/elements/detail/thumbnail/ThumbnailDefault';
import DefaultDescription from '~/components/elements/detail/description/DefaultDescription';
import ModuleProductDetailDescription from '~/components/elements/detail/modules/ModuleProductDetailDescription';
import ModuleDetailShoppingActions from '~/components/elements/detail/modules/ModuleDetailShoppingActions';
import ModuleProductDetailSpecification from '~/components/elements/detail/modules/ModuleProductDetailSpecification';
import ModuleProductDetailSharing from '~/components/elements/detail/modules/ModuleProductDetailSharing';
import ModuleDetailActionsMobile from '~/components/elements/detail/modules/ModuleDetailActionsMobile';
import ModuleDetailTopInformation from '~/components/elements/detail/modules/ModuleDetailTopInformation';
import ProductRepository from '~/repositories/ProductRepository';
import { useState } from 'react';
import { useEffect } from 'react';

const ProductDetailFullwidth = ({ product }) => {
    const [dataDetail, setDataDetail] = useState();
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
        <div className="ps-product--detail ps-product--fullwidth">
            <div className="ps-product__header">
                <ThumbnailDefault productDetail={dataDetail} />
                <div className="ps-product__info">
                    <ModuleDetailTopInformation product={product} />
                    <ModuleProductDetailDescription product={product} />
                    {product.quantity > 0 ? (
                        <ModuleDetailShoppingActions product={product} />
                    ) : (
                        <div
                            style={{
                                fontSize: '25px',
                                borderBottom: '1px solid #e1e1e1',
                                width: '100%',
                                paddingBottom: '22px',
                            }}>
                            <strong>Item out of stocks</strong>
                        </div>
                    )}
                    <ModuleProductDetailSpecification />
                    <ModuleProductDetailSharing />
                    <ModuleDetailActionsMobile product={product} />
                </div>
            </div>
            <DefaultDescription
                product={product}
                productDetail={dataDetail && dataDetail}
            />
        </div>
    );
};

export default ProductDetailFullwidth;
