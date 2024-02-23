import { RouteInfo } from './sidebar.metadata';

export const ROUTES: RouteInfo[] = [
  {
    path: '',
    title: 'Personal',
    icon: 'mdi mdi-dots-horizontal',
    class: 'nav-small-cap',
    extralink: true,
    submenu: []
  },
  {
    path: '/portal',
    title: 'Dashboard',
    icon: 'mdi mdi-view-dashboard',
    class: '',
    extralink: false,
    submenu: []
  },
  {
    path: '/admin/institutes',
    title: 'Institutes',
    icon: 'mdi mdi-school',
    class: '',
    extralink: false,
    submenu: []
  },
  {
    path: '/admin/categories',
    title: 'Categories',
    icon: 'mdi mdi-clipboard-text',
    class: '',
    extralink: false,
    submenu: []
  },
  {
    path: '/admin/subjects',
    title: 'Subjects',
    icon: 'mdi mdi-book-multiple',
    class: '',
    extralink: false,
    submenu: []
  },
  {
    path: '/admin/chapters',
    title: 'Chapters',
    icon: 'mdi mdi-file',
    class: '',
    extralink: false,
    submenu: []
  },
  {
    path: '/admin/user-join-requests',
    title: 'User Join Requests',
    icon: 'mdi mdi-account-check',
    class: '',
    extralink: false,
    submenu: []
  }
];
