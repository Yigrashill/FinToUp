import React from 'react'
import { Link, NavLink } from 'react-router-dom';
import logo from '../images/logo.png';

const Navbar = () => {

  return (
      <nav className ='bg-stone-950'>
          <div className='mx-auto max-w-7xl px-2 sm:px-6 lg:px-8'>
              <div className='flex h-20 items-center justify-between'>
                  <div className='flex flex-1 items-center justity-center md:items-strecht md:justify-start'>
                      <Link to='/home' className='flex flex-shrink=0 items-center mr-4 ' >
                      <img className='h-10 w-auto' src={logo} alt='React Jobs' />
                      <span className='hidden md:block text-white text-2xl font-bold ml-2'>
                          Fin To Up
                      </span>
                      </Link>
                      <div className='md:ml-auto text-zinc-100  justify-center font-sans font-bold'>
                          <div className="flex-1 bg-green-950 hover:bg-green-900 p-2">
                              <NavLink to='/Dashbord'>Dashbord</NavLink>
                          </div>
                          <div className="flex-2 bg-green-950 hover:bg-green-900 p-2">
                              <NavLink to='/Dashbord'>Dashbord</NavLink>
                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </nav>
  );
};

export default Navbar;