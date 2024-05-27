import './App.css';
import { Route,
   createBrowserRouter,
   createRoutesFromElements,
   RouterProvider 
  } from 'react-router-dom'; 
import MainLayout from './layouts/MainLayout';
import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';

const router = createBrowserRouter(
  createRoutesFromElements(
  <Route path='/' element={<MainLayout />} >
    <Route index element={<HomePage /> } />
    <Route path='/home' element = { <HomePage /> } />
    <Route path='*' index element={ <NotFoundPage /> } />
  </Route>)
);


const App = () => {
  return (
    <>
      <RouterProvider router={router} />
    </>
  );
}

export default App;
