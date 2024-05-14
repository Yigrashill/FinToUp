import React, { Component } from 'react';
import logo from '../images/logo.png';
import { NavLink, Link } from 'react-router-dom';


const Navbar = () => {

    type LinkClassProps = {
        isActive?: boolean; 
      };
      
      const linkClass = ({ isActive = false }: LinkClassProps): string =>
        isActive
          ? 'bg-black text-white hover:bg-gray-900 hover:text-white rounded-md px-3 py-2'
          : 'text-white hover:bg-gray-900 hover:text-white rounded-md px-3 py-2';

    return (
        <nav className='bg-indigo-700'>
            <div className='mx-auto max-w-7xl px-2 sm:px-6 lg:px-8'>
                <div className='flex h-20 items-center justify-between'>
                    <div className='flex flex-1 items-center justity-center md:items-strecht md:justify-start'>
                        <Link to='/' className='flex flex-shrink=0 items-center mr-4 ' >
                        <img className='h-10 w-auto' src={logo} alt='React Jobs' />
                        <span className='hidden md:block text-white text-2xl font-bold ml-2'>
                            React Jobs
                        </span>
                        </Link>
                        <div className='md:ml-auto text-white '>
                            <div className="flex space-x-2">
                                <NavLink to='' className= {linkClass}>Home</NavLink>
                                <NavLink to='/jobs' className= {linkClass}>Jobs</NavLink>
                                <NavLink to='/add-job' className= {linkClass}>Add Job</NavLink>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    );
  };

export default Navbar;