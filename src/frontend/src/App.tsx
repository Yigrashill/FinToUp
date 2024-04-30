import  HomePage  from './pages/HomePage'
import MainLayout from './layouts/MainLayout';
import { Route, createBrowserRouter, createRoutesFromElements, RouterProvider } from 'react-router-dom'
import JobsPage from './pages/JobsPage';
import NotFoundPage from './pages/NotFoundPage';

const router = createBrowserRouter(
  createRoutesFromElements(
  <Route path='/' element={<MainLayout />} >
    <Route index element={ <HomePage />} /> 
    <Route path='/Home'  element={ <HomePage />} /> 
    <Route path='/Jobs' index element={ <JobsPage /> } />
    <Route path='*' index element={ <NotFoundPage /> } />
  </Route>)
);


const App = () => {
  return (
    <>
      <RouterProvider router={router} />

    </>
  )
}

export default App