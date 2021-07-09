<template>
  <v-card>
    <v-toolbar dense>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
    </v-toolbar>

    <v-navigation-drawer :clipped="clipped" v-model="drawer" enable-resize-watcher app dark class="lighten-3">
      <v-list nav dense>

        <v-list-item-group v-model="group">
        <v-list-item v-for="item in listItems" :key="item.title" :to="item.path">
          <v-list-item-action><v-icon>{{ item.icon }}</v-icon></v-list-item-action>
          <v-list-item-content>{{item.title}}</v-list-item-content>
        </v-list-item>
        </v-list-item-group>

        <v-list-group :value="false" prepend-icon="settings">
          <template v-slot:activator>
              <v-list-item-title>Admin</v-list-item-title>
          </template>

          <v-list-item v-for="obj in admin" :key="obj.title" :to="obj.path">
            <v-list-item-action><v-icon>{{ obj.icon }}</v-icon></v-list-item-action>
            <v-list-item-content>{{obj.title}}</v-list-item-content>
          </v-list-item>
        </v-list-group>

      </v-list>
    </v-navigation-drawer>
  </v-card>
</template>

<script>
export default {
    name: 'NavBar',
    data() {
      return {
        drawer: true,
        group: true,
        name: 'Vue SPA Nettbutikk',
        clipped: false,
        listItems: [
          //{title: 'Home', path: '/', icon: 'home'},
          {title: 'Products', path: '/products', icon: 'inventory_2'}
        ],
        admin: [
          {title: 'Add Product', path: '/addProducts', icon: 'add'},
          {title: 'Update Product', path: '/updateProducts', icon: 'sync'},
          {title: 'Delete Product', path: '/deleteProducts', icon: 'remove'}
        ]
      }
    },
    watch: {
      drawer(value) {
        return value;
      }
    }
}
</script>

<style>
</style>