import React, { Component } from 'react';
import logo from '../images/logo.png';

const Navbar = () => {
    return (
        <nav className='bg-indigo-700 border-b border-indigo-500'>
            <div className='mx-auto max-w-7xl px-2 sm:px-6 lg:px-8'>
                <div className='flex h-20 items-center justify-between'>
                    <div className='flex flex-1 items-center justity-center md:items-strecht md:justify-start'>
                        <a className='flex flex-shrink=0 items-center mr-4 ' href='/index.html'/>
                        <img className='h-10 w-auto' src={logo} alt='React Jobs' />
                        <span className='hidden md:block text-white text-2xl font-bold ml-2'>
                            React Jobs
                        </span>

                        <div className='md:ml-auto'>
                            <div className='flex space=x-2'>
                                Home
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    );
  };

export default Navbar;