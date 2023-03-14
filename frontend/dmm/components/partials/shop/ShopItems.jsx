import React, { useEffect, useState } from 'react';
import { Pagination } from 'antd';
import Product from '~/components/elements/products/Product';
import ProductWide from '~/components/elements/products/ProductWide';
import ProductRepository from '~/repositories/ProductRepository';
import { generateTempArray } from '~/utilities/common-helpers';
import SkeletonProduct from '~/components/elements/skeletons/SkeletonProduct';
import useGetProducts from '~/hooks/useGetProducts';

const ShopItems = ({
    cateId = null,
    brandId = null,
    columns = 4,
    pageSize = 2,
}) => {
    const [page, setPage] = useState(1);
    const [totalProduct, setProduct] = useState(null);
    const [listView, setListView] = useState(true);
    const [classes, setClasses] = useState(
        'col-xl-4 col-lg-4 col-md-3 col-sm-6 col-6'
    );
    const {
        productItems,
        setProductItems,
        loading,
        getProducts,
        setLoading,
    } = useGetProducts();

    function handleChangeViewMode(e) {
        e.preventDefault();
        setListView(!listView);
    }

    function handlePagination(e) {
        setPage(e);
        if (cateId) {
            getProductByCate(e);
        } else if (brandId) {
            getProductByBrand(e);
        }
    }
    async function getProductByBrand(pageIndex) {
        setLoading(true);
        const responseData = await ProductRepository.getProductsByBrand(
            brandId,
            pageIndex,
            pageSize
        );
        if (responseData) {
            setProductItems(responseData.data);
            setProduct(responseData.totalItem);
        } else {
            setProductItems(null);
        }
        setLoading(false);
    }
    async function getProductByCate(pageIndex) {  
        setLoading(true);
        const responseData = await ProductRepository.getProductsByCategory(
            cateId,
            pageIndex,
            pageSize
        );
        if (responseData) {
            setProductItems(responseData.data);
            setProduct(responseData.totalItem);
        } else {
            setProductItems(null);
        }
        setLoading(false);
    }
    function handleSetColumns() {
        switch (columns) {
            case 2:
                setClasses('col-xl-6 col-lg-6 col-md-6 col-sm-6 col-6');
                return 3;
                break;
            case 4:
                setClasses('col-xl-3 col-lg-4 col-md-6 col-sm-6 col-6');
                return 4;
                break;
            case 6:
                setClasses('col-xl-2 col-lg-4 col-md-6 col-sm-6 col-6');
                return 6;
                break;

            default:
                setClasses('col-xl-4 col-lg-4 col-md-3 col-sm-6 col-6');
        }
    }

    useEffect(() => {
        if (cateId !== null) {
            getProductByCate(1);
        } else if (brandId !== null) {
            getProductByBrand(1);
        } else {
            getProducts();
        }
        handleSetColumns();
    }, [cateId, brandId]);
    // Views
    let productItemsView;
    if (!loading) {
        if (productItems && productItems.length > 0) {
            if (listView) {
                const items = productItems.map((item) => (
                    <div className={classes} key={item.id}>
                        <Product product={item} />
                    </div>
                ));
                productItemsView = (
                    <div className="ps-shop-items">
                        <div className="row">{items}</div>
                    </div>
                );
            } else {
                productItemsView = productItems.map((item) => (
                    <ProductWide product={item} />
                ));
            }
        } else {
            productItemsView = <p>No product found.</p>;
        }
    } else {
        const skeletonItems = generateTempArray(12).map((item) => (
            <div className={classes} key={item}>
                <SkeletonProduct />
            </div>
        ));
        productItemsView = <div className="row">{skeletonItems}</div>;
    }

    return (
        <div className="ps-shopping">
            <div className="ps-shopping__header">
                <p>
                    <strong className="mr-2">
                        {productItems && productItems.length
                            ? productItems.length
                            : 0}
                    </strong>
                    Products found
                </p>
                <div className="ps-shopping__actions">
                    <div className="ps-shopping__view">
                        <p>View</p>
                        <ul className="ps-tab-list">
                            <li className={listView === true ? 'active' : ''}>
                                <a
                                    href="#"
                                    onClick={(e) => handleChangeViewMode(e)}>
                                    <i className="icon-grid"></i>
                                </a>
                            </li>
                            <li className={listView !== true ? 'active' : ''}>
                                <a
                                    href="#"
                                    onClick={(e) => handleChangeViewMode(e)}>
                                    <i className="icon-list4"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div className="ps-shopping__content">{productItemsView}</div>
            <div className="ps-shopping__footer text-center">
                <div className="ps-pagination">
                    <Pagination
                        total={totalProduct && totalProduct}
                        pageSize={pageSize}
                        responsive={true}
                        showSizeChanger={false}
                        current={page !== undefined ? parseInt(page) : 1}
                        onChange={(e) => handlePagination(e)}
                    />
                </div>
            </div>
        </div>
    );
};

export default ShopItems;
