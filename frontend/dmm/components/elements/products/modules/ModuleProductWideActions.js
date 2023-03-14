import React from 'react';
import { connect } from 'react-redux';
import { Modal } from 'antd';
import useProduct from '~/hooks/useProduct';
import useEcomerce from '~/hooks/useEcomerce';
import CartRepository from '~/repositories/CartRepository';
import { notification } from 'antd';

const ModuleProductWideActions = ({ ecomerce, product }) => {
    const { price } = useProduct();
    const { addItem } = useEcomerce();
    function handleAddItemToCart(e) {
        e.preventDefault();
        addItem({ id: product.id, quantity: 1 }, ecomerce.cartItems, 'cart');
        const userInfo = JSON.parse(localStorage.getItem('account'));
        if (userInfo) {
            let payload = {};
            payload.productId = product.id;
            payload.quantity = 1;
            payload.name = userInfo.name;
            payload.description = '';
            const result = CartRepository.addToCart(payload);
            if (result) {
                notification['success']({
                    message: 'Success',
                    description: 'Add to cart Success',
                });
            }
            addItem(
                { id: product.id, quantity: 1 },
                ecomerce.cartItems,
                'cart'
            );
        } else {
            notification['warning']({
                message: 'Add To Cart Failed',
                description: 'You must login',
            });
        }
    }

    function handleAddItemToWishlist(e) {
        e.preventDefault();
        addItem({ id: product.id }, ecomerce.wishlistItems, 'wishlist');
        const modal = Modal.success({
            centered: true,
            title: 'Success!',
            content: `This item has been added to your wishlist`,
        });
        modal.update;
    }

    function handleAddItemToCompare(e) {
        e.preventDefault();
        addItem({ id: product.id }, ecomerce.compareItems, 'compare');
        const modal = Modal.success({
            centered: true,
            title: 'Success!',
            content: `This product has been added to your compare listing!`,
        });
        modal.update;
    }

    return (
        <div className="ps-product__shopping">
            {price(product)}
            {product.quantity > 0 ? (
                <div>
                    <a
                        className="ps-btn"
                        href="#"
                        onClick={(e) => handleAddItemToCart(e)}>
                        Add to cart
                    </a>
                    <ul className="ps-product__actions">
                        <li>
                            <a
                                href="#"
                                onClick={(e) => handleAddItemToWishlist(e)}>
                                <i className="icon-heart"></i> Wishlist
                            </a>
                        </li>
                        <li>
                            <a
                                href="#"
                                onClick={(e) => handleAddItemToCompare(e)}>
                                <i className="icon-chart-bars"></i> Compare
                            </a>
                        </li>
                    </ul>
                </div>
            ) : (
                <strong>Product out of stock</strong>
            )}
        </div>
    );
};

export default connect((state) => state)(ModuleProductWideActions);
